defmodule Scrabble do
  
  @scorecard  %{"a" => 1, "b" => 3, "c" => 3, "d" => 2, "e" => 1, "f" => 4, "g" => 2, "h" => 4, "i" => 1,  "j" => 8, "k" => 5, "l" => 1, "m" => 3, "n" => 1, "o" => 1, "p" => 3, "q" => 10, "r" => 1, "s" => 1, "t" => 1, "u" => 1, "v" => 4, "w" => 4, "x" => 8, "y" => 4, "z" => 10 }

  @doc """
  Calculate the scrabble score for the word.
  """

  @spec score2(String.t()) :: non_neg_integer
  def score2(word) do
    word 
    |> String.trim
    |> String.downcase
    |> String.graphemes
    |> Enum.reduce(0, fn letter, acc -> acc + @scorecard[letter] end )
  end

  @spec score(String.t()) :: non_neg_integer
  def score(""), do: 0
  def score("a" <> word), do: 1 + score(word)
  def score("b" <> word), do: 3 + score(word)
  def score("c" <> word), do: 3 + score(word)
  def score("d" <> word), do: 2 + score(word)
  def score("e" <> word), do: 1 + score(word)
  def score("f" <> word), do: 4 + score(word)
  def score("g" <> word), do: 2 + score(word)
  def score("h" <> word), do: 4 + score(word)
  def score("i" <> word), do: 1 + score(word)
  def score("j" <> word), do: 8 + score(word)
  def score("k" <> word), do: 5 + score(word)
  def score("l" <> word), do: 1 + score(word)
  def score("m" <> word), do: 3 + score(word)
  def score("n" <> word), do: 1 + score(word)
  def score("o" <> word), do: 1 + score(word)
  def score("p" <> word), do: 3 + score(word)
  def score("q" <> word), do: 10 + score(word)
  def score("r" <> word), do: 1 + score(word)
  def score("s" <> word), do: 1 + score(word)
  def score("t" <> word), do: 1 + score(word)
  def score("u" <> word), do: 1 + score(word)
  def score("v" <> word), do: 4 + score(word)
  def score("w" <> word), do: 4 + score(word)
  def score("x" <> word), do: 8 + score(word)
  def score("y" <> word), do: 4 + score(word)
  def score("z" <> word), do: 10 + score(word)
  
  # if it doesn't match one of the others, clean, and filter.
  def score(word), do: word |> String.downcase |> String.replace(~r/([^a-z])/,"") |> score
  
end
