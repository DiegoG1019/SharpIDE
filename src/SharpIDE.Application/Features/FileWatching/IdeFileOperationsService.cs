using SharpIDE.Application.Features.SolutionDiscovery;

namespace SharpIDE.Application.Features.FileWatching;

public class IdeFileOperationsService(SharpIdeSolutionModificationService sharpIdeSolutionModificationService)
{
	private readonly SharpIdeSolutionModificationService _sharpIdeSolutionModificationService = sharpIdeSolutionModificationService;

	public async Task CreateDirectory(SharpIdeFolder parentFolder, string directoryPath)
	{
		var newFolder = await _sharpIdeSolutionModificationService.CreateDirectory(parentFolder, directoryPath);
		Directory.CreateDirectory(directoryPath);
	}
}
