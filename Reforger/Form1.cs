using Microsoft.VisualBasic;
using System.IO.Compression;
using System.Text.Json;

namespace Reforger
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient _client = new()
        {
            BaseAddress = new Uri("https://api.modrinth.com/v2/")
        };

        private readonly List<string> _available = [];
        private readonly List<string> _unavailable = [];
        private readonly List<string> _notFound = [];
        private readonly List<ModrinthEntry> _toDownload = [];

        public Form1()
        {
            InitializeComponent();
            _client.DefaultRequestHeaders.Add("User-Agent", "github/ncgtr (mod updater app)");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.Text = textBox1.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".minecraft", "mods");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog
            {
                Multiselect = false,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            };

            if (fbd.ShowDialog() == DialogResult.OK)
                textBox1.Text = fbd.SelectedPath;
        }

        private void RefreshUI(object sender, EventArgs e)
        {
            RefreshFileList();

            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text))
            {
                button2.Enabled = false;
            }

            button3.Enabled = false;
        }

        private void RefreshFileList()
        {
            checkedListBox1.Items.Clear();
            button3.Enabled = false;

            if (!Directory.Exists(textBox1.Text))
            {
                label12.Text = "Found JAR Files (0)";
                button2.Enabled = false;
                return;
            }

            foreach (string file in Directory.GetFiles(textBox1.Text, "*.jar"))
                checkedListBox1.Items.Add(file);

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);

            label12.Text = $"Found JAR Files ({checkedListBox1.Items.Count})";
            button2.Enabled = checkedListBox1.Items.Count > 0;
        }

        private void RefreshStatus()
        {
            label5.Text = $"{_available.Count} Updates Available";
            label6.Text = $"{_unavailable.Count} Outdated";
            label8.Text = $"{_notFound.Count} Not Found on Modrinth";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            _available.Clear();
            _unavailable.Clear();
            _notFound.Clear();
            _toDownload.Clear();

            SetControlsEnabled(false);
            await ExtractNamesAsync(checkedListBox1.CheckedItems.Cast<string>().ToList());
            SetControlsEnabled(true);

            RefreshStatus();
            button3.Enabled = _available.Count > 0 && !string.IsNullOrEmpty(textBox4.Text);
        }

        private async Task ExtractNamesAsync(IEnumerable<string> jars)
        {
            foreach (string jar in jars)
            {
                try
                {
                    using ZipArchive archive = ZipFile.OpenRead(jar);
                    ZipArchiveEntry? fabricModJson = archive.GetEntry("fabric.mod.json");
                    if (fabricModJson == null)
                        continue;

                    using StreamReader reader = new(fabricModJson.Open());
                    using JsonDocument doc = JsonDocument.Parse(await reader.ReadToEndAsync());

                    if (doc.RootElement.TryGetProperty("name", out JsonElement name))
                        await QueryAsync(name.GetString() ?? string.Empty, textBox2.Text, textBox3.Text);
                }
                catch (Exception ex)
                {
                    ShowError($"Failed to read {Path.GetFileName(jar)}:\n\n{ex.Message}");
                }
            }
        }

        private async Task QueryAsync(string modName, string gameVersion, string loader)
        {
            try
            {
                using var searchResp = await _client.GetAsync(
                    $"search?query={Uri.EscapeDataString(modName)}&limit=1");
                searchResp.EnsureSuccessStatusCode();
                using JsonDocument searchDoc = JsonDocument.Parse(
                    await searchResp.Content.ReadAsStringAsync());

                JsonElement hits = searchDoc.RootElement.GetProperty("hits");
                if (hits.GetArrayLength() == 0)
                {
                    _notFound.Add(modName);
                    RefreshStatus();
                    return;
                }

                string projectId = hits[0].GetProperty("project_id").GetString() ?? "Unknown";

                string versionUrl = $"project/{projectId}/version" +
                    $"?loaders={Uri.EscapeDataString($"[\"{loader}\"]")}" +
                    $"&game_versions={Uri.EscapeDataString($"[\"{gameVersion}\"]")}";

                using var versionResp = await _client.GetAsync(versionUrl);
                versionResp.EnsureSuccessStatusCode();
                using JsonDocument versionDoc = JsonDocument.Parse(
                    await versionResp.Content.ReadAsStringAsync());

                if (versionDoc.RootElement.GetArrayLength() == 0)
                {
                    _unavailable.Add(modName);
                    RefreshStatus();
                    return;
                }

                JsonElement files = versionDoc.RootElement[0].GetProperty("files");
                _available.Add(modName);
                _toDownload.Add(new ModrinthEntry
                {
                    ModName = modName,
                    FileName = files[0].GetProperty("filename").GetString() ?? "unknown.jar",
                    DownloadUrl = files[0].GetProperty("url").GetString() ?? string.Empty
                });

                RefreshStatus();
            }
            catch (Exception ex)
            {
                ShowError($"Error querying '{modName}':\n\n{ex.Message}");
            }
        }

        private static async Task DownloadAsync(ModrinthEntry mod, string path)
        {
            using HttpResponseMessage response = await _client.GetAsync(
                mod.DownloadUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            using Stream networkStream = await response.Content.ReadAsStreamAsync();
            using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None);
            await networkStream.CopyToAsync(fileStream);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            SetControlsEnabled(false);
            if (!Directory.Exists(textBox4.Text))
                Directory.CreateDirectory(textBox4.Text);
            try
            {
                foreach (ModrinthEntry mod in _toDownload)
                {
                    try
                    {
                        await DownloadAsync(mod, Path.Combine(textBox4.Text, mod.FileName));
                    }
                    catch (Exception ex)
                    {
                        ShowError($"Failed to download {mod.FileName}:\n\n{ex.Message}");
                    }
                }
                ShowInfo("All tasks completed");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            textBox1.Enabled = enabled;
            textBox2.Enabled = enabled;
            textBox3.Enabled = enabled;
            textBox4.Enabled = enabled;
            button1.Enabled = enabled;
            button2.Enabled = enabled;
            button3.Enabled = enabled;
            checkedListBox1.Enabled = enabled;
        }

        private void ShowError(string message) =>
            MessageBox.Show(message, "Reforger", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ShowInfo(string message) =>
            MessageBox.Show(message, "Reforger", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void label5_Click(object sender, EventArgs e) =>
            ShowInfo("Updates available:\n" + string.Join(Environment.NewLine, _available));

        private void label6_Click(object sender, EventArgs e) =>
            ShowInfo("Outdated mods:\n" + string.Join(Environment.NewLine, _unavailable));

        private void label8_Click(object sender, EventArgs e) =>
            ShowInfo("Not found on Modrinth:\n" + string.Join(Environment.NewLine, _notFound));

        private void textBox4_TextChanged(object sender, EventArgs e) =>
            button3.Enabled = _available.Count > 0
                           && !string.IsNullOrEmpty(textBox4.Text)
                           && !File.Exists(textBox4.Text);

        private void button4_Click(object sender, EventArgs e) =>
            ShowInfo("1. Reforger does not check for any dependencies of the mods. It simply updates your existing mods!\n" +
                "2. For a mod to be flagged as available to update, the version you specified must match exactly.");
    }

    public class ModrinthEntry
    {
        public string ModName { get; init; } = "Unknown";
        public string FileName { get; init; } = "Unknown";
        public string DownloadUrl { get; init; } = string.Empty;
    }
}