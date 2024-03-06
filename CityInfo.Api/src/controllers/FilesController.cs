
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.Api.src.controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
    public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    {
        _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
    }
    [HttpGet("{FileId}")]
    public ActionResult GetFile(string FileId){
        var  filePath = "./resource/Pro_C_9_with_.NET_5_Foundational_Principles_and_Practices_in_Programming_-_Tenth_Edition_Andrew_Troelsen_Phillip_Japikse_Z-Library.pdf";
        if(!System.IO.File.Exists(filePath)){
            return NotFound();
        }
        if(!_fileExtensionContentTypeProvider.TryGetContentType(filePath, out var contentType)){
            contentType = "application/octet-stream";
        }
        var bytes = System.IO.File.ReadAllBytes(filePath);
        return File(bytes, contentType, Path.GetFileName(filePath));
    }
}