defmodule Bob do
  
  
  defp question?(input) do
    String.ends_with?(input, "?")
  end

  defp yell?(input) do
    input =~ ~r(\p{Lu}[^\p{Ll}*])
  end

  defp blank?(input) do
    input == nil || String.length(String.trim(input)) == 0
  end

  @doc """
    This method computes bob's response to different input statements.
    Bob answers 'Sure.' if you ask him a question.
    He answers 'Whoa, chill out!' if you yell at him.
    He answers 'Calm down, I know what I'm doing!' if you yell a question at him.
    He says 'Fine. Be that way!' if you address him without actually saying anything.
    He answers 'Whatever.' to anything else.
  """
  @spec hey(String) :: String
  def hey(input) do
    cond do 
      yell?(input) and question?(input) -> "Calm down, I know what I'm doing!"
      question?(input) -> "Sure."
      yell?(input) -> "Whoa, chill out!"
      blank?(input) ->  "Fine. Be that way!"
      true -> "Whatever."
    end
  end
end

