defmodule PigLatin do
  @doc """
  Given a `phrase`, translate it a word at a time to Pig Latin.

  Words beginning with consonants should have the consonant moved to the end of
  the word, followed by "ay".

  Words beginning with vowels (aeiou) should have "ay" added to the end of the
  word.

  Some groups of letters are treated like consonants, including "ch", "qu",
  "squ", "th", "thr", and "sch".

  Some groups are treated like vowels, including "yt" and "xr".
  """
  @spec translate(phrase :: String.t()) :: String.t()

  @consonant_with_y_capture ~r/(?<sound>^([bcdfghjklmnpqrstvwxz]{1,2}y))/
  @consonant_with_y_pattern ~r/^([bcdfghjklmnpqrstvwxz]{1,2}y)/
  @consonant_with_qu_capture ~r/(?<sound>^([bcdfghjklmnprstvwxyz]{0,}qu))/
  @consonant_with_qu_pattern ~r/^([bcdfghjklmnprstvwxyz]{0,}qu)/
  @consonant_sounding_capture ~r/(?<sound>^([bcdfghjklmnpqrstvwxyz]{1,}))/
  @consonant_sounding_pattern ~r/^([bcdfghjklmnpqrstvwxyz]{1,})/
  @vowel_sounding_pattern ~r/^(([yd]{2})|([yt]{2})|([xb]{2})|([xr]{2})|([aeiou]{1}))/

  def translate(phrase) do
    phrase 
      |> String.split
      |> Enum.map( fn p -> trans(p) end)
      |> Enum.join(" ")
  end
  def trans(phrase) do
    cond do
      beginsWithVowelSound(phrase) ->
        phrase <> "ay"
      beginsWithConsonantQUSound(phrase)->
        sound = captureSound(phrase, @consonant_with_qu_capture)
        base = String.trim_leading(phrase, sound)
        base <> sound <>"ay"
      beginsWithConsonantYSound(phrase)->
        sound = captureSound(phrase, @consonant_with_y_capture)
        base = String.trim_leading(phrase, sound)
        base <> sound <>"ay"
      beginswithConsonantSound(phrase) ->
        sound = captureSound(phrase, @consonant_sounding_capture)
        base = String.trim_leading(phrase, sound)
        base <> sound <>"ay"
      true -> 
        phrase <> "ay"
    end
  end
  
  defp beginsWithVowelSound(phrase) do
    String.match?(phrase, @vowel_sounding_pattern)
  end

  defp beginswithConsonantSound(phrase) do
    String.match?(phrase, @consonant_sounding_pattern)
  end
  
  defp beginsWithConsonantQUSound(phrase) do
    String.match?(phrase, @consonant_with_qu_pattern)
  end

  defp beginsWithConsonantYSound(phrase) do
    String.match?(phrase, @consonant_with_y_pattern)
  end

  defp captureSound(phrase, capture_pattern) do
    Regex.named_captures(capture_pattern, phrase)
    |> Map.get("sound")
  end
end
