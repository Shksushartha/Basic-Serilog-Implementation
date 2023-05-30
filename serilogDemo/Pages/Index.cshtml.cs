using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace serilogDemo.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("this is the log");
        try
        {
            for(int i = 0; i<50; i++)
            {
                if(i == 25)
                {
                    throw new Exception("This is the 25 error");
                }
                else
                {
                    _logger.LogInformation("The value of i is {i}", i);
                }

            }
        }
        catch(Exception ex)
        {
            _logger.LogError(ex,"the error is catched");
        }

    }
}

