using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Smart.Design.Pagination.Sample.Models.Options;
using Smart.Design.Pagination.Sample.Models.SuperHeroApi;

namespace Smart.Design.Pagination.Sample.Pages;

public class IndexModel : PageModel
{
    private static List<SuperHero> _superHeroes = new();

    private readonly PaginationOptions _paginationSettings;

    [BindProperty(SupportsGet = true)]
    public int PageIndex { get; set; } = 1;

    public int NumberOfPageInNavBar => _paginationSettings.NumberOfSquares;

    public PaginatedList<SuperHero> SuperHeroes { get; set; } = null!;

    public IndexModel(IOptionsMonitor<PaginationOptions> paginationOptions)
    {
        _paginationSettings = paginationOptions.CurrentValue ?? throw new ArgumentException();
    }

    public async Task<ActionResult> OnGetAsync()
    {
        // We want to avoid skipping with a negative value when paginating.
        PageIndex = Math.Max(PageIndex, 1);

        // Fetch the SuperHeroes and catch them in a static List.
        await FetchSuperHeroesAsync();

        SuperHeroes = _superHeroes.Paginate(PageIndex, _paginationSettings.PageSize);

        // User attempted to access a page that exceeds the total page.
        if (PageIndex != 1 && !SuperHeroes.Any())
        {
            return RedirectToPage();
        }

        return Page();
    }

    private static async Task FetchSuperHeroesAsync()
    {
        if (_superHeroes.Count == 0)
        {
            _superHeroes = await new HttpClient().GetFromJsonAsync<List<SuperHero>>(AllSuperHeroes)
                           ?? throw new InvalidOperationException("Couldn't retrieve the super heroes list.");
        }
    }

    private const string AllSuperHeroes = "https://cdn.jsdelivr.net/gh/akabab/superhero-api@0.3.0/api/all.json";
}
