using SharpIDE.Application.Features.SolutionDiscovery;
using SharpIDE.Application.Features.SolutionDiscovery.VsPersistence;

namespace SharpIDE.Application.Features.FileWatching;

public class SharpIdeSolutionModificationService
{
	public SharpIdeSolutionModel SolutionModel { get; set; } = null!;

	public async Task<SharpIdeFolder> CreateDirectory(SharpIdeFolder parentFolder, string directoryPath)
	{
		// Passing [] to allFiles and allFolders, as we assume that a brand new folder has no subfolders or files yet
		var sharpIdeFolder = new SharpIdeFolder(new DirectoryInfo(directoryPath), parentFolder, [], []);
		parentFolder.Folders.Add(sharpIdeFolder);
		SolutionModel.AllFolders.Add(sharpIdeFolder);
		return sharpIdeFolder;
	}
}
