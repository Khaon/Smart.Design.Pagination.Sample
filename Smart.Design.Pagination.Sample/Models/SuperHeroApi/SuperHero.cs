using System.Text.Json.Serialization;

namespace Smart.Design.Pagination.Sample.Models.SuperHeroApi;

public  class SuperHero
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("powerstats")]
    public Powerstats Powerstats { get; set; }

    [JsonPropertyName("appearance")]
    public Appearance Appearance { get; set; }

    [JsonPropertyName("biography")]
    public Biography Biography { get; set; }

    [JsonPropertyName("work")]
    public Work Work { get; set; }

    [JsonPropertyName("connections")]
    public Connections Connections { get; set; }

    [JsonPropertyName("images")]
    public Images Images { get; set; }
}

public  class Appearance
{
    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("race")]
    public string Race { get; set; }

    [JsonPropertyName("height")]
    public List<string> Height { get; set; }

    [JsonPropertyName("weight")]
    public List<string> Weight { get; set; }

    [JsonPropertyName("eyeColor")]
    public string EyeColor { get; set; }

    [JsonPropertyName("hairColor")]
    public string HairColor { get; set; }
}

public  class Biography
{
    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("alterEgos")]
    public string AlterEgos { get; set; }

    [JsonPropertyName("aliases")]
    public List<string> Aliases { get; set; }

    [JsonPropertyName("placeOfBirth")]
    public string PlaceOfBirth { get; set; }

    [JsonPropertyName("firstAppearance")]
    public string FirstAppearance { get; set; }

    [JsonPropertyName("publisher")]
    public string Publisher { get; set; }

    [JsonPropertyName("alignment")]
    public string Alignment { get; set; }
}

public  class Connections
{
    [JsonPropertyName("groupAffiliation")]
    public string GroupAffiliation { get; set; }

    [JsonPropertyName("relatives")]
    public string Relatives { get; set; }
}

public  class Images
{
    [JsonPropertyName("xs")]
    public Uri Xs { get; set; }

    [JsonPropertyName("sm")]
    public Uri Sm { get; set; }

    [JsonPropertyName("md")]
    public Uri Md { get; set; }

    [JsonPropertyName("lg")]
    public Uri Lg { get; set; }
}

public  class Powerstats
{
    [JsonPropertyName("intelligence")]
    public int Intelligence { get; set; }

    [JsonPropertyName("strength")]
    public int Strength { get; set; }

    [JsonPropertyName("speed")]
    public int Speed { get; set; }

    [JsonPropertyName("durability")]
    public int Durability { get; set; }

    [JsonPropertyName("power")]
    public int Power { get; set; }

    [JsonPropertyName("combat")]
    public int Combat { get; set; }
}

public  class Work
{
    [JsonPropertyName("occupation")]
    public string Occupation { get; set; }

    [JsonPropertyName("base")]
    public string Base { get; set; }
}