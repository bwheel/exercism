defmodule Words do

  @whites_space ~r(\s+)
  @connector_punctuation ~r([\p{Pc}])
  @symbols ~r([\p{S}\,\.\%\&\:\@\!])
  
  @doc """
  Count the number of words in the sentence.

  Words are compared case-insensitively.
  """
  @spec count(String.t()) :: map
  def count(sentence) do
    
    String.replace(sentence, @symbols, "")
    |> String.replace(@connector_punctuation, " ")
    |> (&Regex.split(@whites_space, &1)).()
    |> Enum.map( fn word -> String.downcase(word, :default) end )
    |> Enum.reduce( %{}, fn word, result -> Map.put( result, word, (Map.get(result, word, 0) + 1 ) ) end )
  end
end
