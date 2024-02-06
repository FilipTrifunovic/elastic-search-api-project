using Nest;

namespace elastic_search_api.Infrastructure.Persistence.Configurations.Analyzers
{
    public static class FullEnglishAnalyzer
    {
        public static IndexSettingsDescriptor AddTextAnalyzers (this IndexSettingsDescriptor s)
        {
            return s.Analysis(a => a
                        .TokenFilters(tf => tf
                            .Stop("english_stop", st => st
                                .StopWords("_english_")
                            )
                            .Stemmer("english_stemmer", st => st
                                .Language("english")
                            )
                            .Stemmer("light_english_stemmer", st => st
                                .Language("light_english")
                            )
                            .Stemmer("english_possessive_stemmer", st => st
                                .Language("possessive_english")
                            )
                            .Synonym("book_synonyms", st => st
                                // If you have a lot of synonyms, it's probably better to create a synonyms
                                // text file and use .SynonymsPath here instead.
                                .Synonyms(
                                    "haphazard,indiscriminate,erratic",
                                    "incredulity,amazement,skepticism")
                            )
                        )
                        .Analyzers(aa => aa
                            .Custom("light_english", ca => ca
                                .Tokenizer("standard")
                                .Filters("light_english_stemmer", "english_possessive_stemmer", "lowercase", "asciifolding")
                            )
                            .Custom("full_english", ca => ca
                                .Tokenizer("standard")
                                .Filters("english_possessive_stemmer",
                                        "lowercase",
                                        "english_stop",
                                        "english_stemmer",
                                        "asciifolding")
                            )
                            .Custom("full_english_synopsis", ca => ca
                                .Tokenizer("standard")
                                .Filters("book_synonyms",
                                        "english_possessive_stemmer",
                                        "lowercase",
                                        "english_stop",
                                        "english_stemmer",
                                        "asciifolding")
                            )
                        )
                    );
        }
    }
}
