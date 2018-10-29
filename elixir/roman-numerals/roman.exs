defmodule Roman do
  @doc """
  Convert the number to a roman number.
  """
  @spec numerals(pos_integer) :: String.t()
  def numerals(number) do
    cond do
      number >= 1000 ->
        "M" <> numerals(number - 1000)
      number >= 900 ->
        "CM" <> numerals(number - 900)
      number >= 500 ->
        "D" <> numerals(number - 500)
      number >= 400 ->
        "CD" <> numerals(number - 400)
      number >= 100 ->
        "C" <> numerals(number - 100)
      number >= 90 ->
        "XC" <> numerals(number - 90)
      number >= 50 -> 
        "L" <> numerals(number - 50)
      number >= 40 ->
        "XL" <> numerals(number - 40)
      number >= 10 ->
        "X" <> numerals(number - 10)
      number >= 9 ->
        "IX" <> numerals(number - 9)
      number >= 5 ->
        "V" <> numerals(number - 5)
      number == 4 ->
        "IV" <> numerals(number - 4)
      number >= 1 ->
        "I" <> numerals(number - 1)
      true -> ""
    end
  end
end
