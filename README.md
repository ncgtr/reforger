# Reforger
### A Windows .NET 10 desktop utility that scans your Minecraft mods folder for outdated mods and downloads the latest compatible versions via the [Modrinth](https://modrinth.com/) API.

`Note: This project is not sponsored by or affiliated with Modrinth in any way. It is purely a hobby and portfolio project.`

<img width="658" height="330" alt="image" src="https://github.com/user-attachments/assets/ac0cc5e7-83f5-456f-be69-9091d9df082b" />

Almost every player build their mods folder with dozens of individually maintained mods. When a new game version releases, each mod has to be updated separately — visiting every page by hand — or the player simply stays on the old version. Reforger reduces everything to two clicks!

**The program currently identifies mods via the Fabric manifest and therefore expects a Fabric mods folder as input.**

Each Minecraft mod is packaged as a `.jar` file, which is simply an archive like any other. Fabric mods include a `fabric.mod.json` manifest inside, which **Reforger** reads to identify the mod by name.

From there, it takes the mod name and sends a search request to the **Modrinth API**, then it filters the return to check if the desired version and loader architecture exists. All network and file I/O is fully `async`/`await` with a static `HttpClient`, keeping the UI responsive. Downloads are streamed directly from the network to disk using `NetworkStream` and `FileStream`, instead of loading entire files into memory then saving them to disk, this avoids excessive use of resources.

Because identification relies on the Fabric manifest, Forge/Quilt etc. mods in the source folder will be skipped. However, the loader you query *for* can be anything Modrinth supports — so Reforger can also serve as a migration tool when moving a mod list from **Fabric** to: **Forge, NeoForge, Quilt, or any other loader available on Modrinth.**

**Here is a working demonstration:**

<img width="658" height="330" alt="Reforger" src="https://github.com/user-attachments/assets/22c3e882-82b3-451c-aaf7-b18d5b6ec95b" />
