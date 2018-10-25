defmodule RNATranscription do
  @doc """
  Transcribes a character list representing DNA nucleotides to RNA

  ## Examples

  iex> RNATranscription.to_rna('ACTG')
  'UGAC'
  """
  @spec to_rna([char]) :: [char]
  def to_rna(dna) do
  dna 
      |> to_string 
      |> String.graphemes
      |> Enum.map( fn nucleotide -> transcribe(nucleotide) end) 
      |> Enum.join 
      |> String.to_charlist
  end

  defp transcribe(nucleotide) do
    case nucleotide do
      "G" -> "C"
      "C" -> "G"
      "T" -> "A"
      "A" -> "U"
    end
  end

end
