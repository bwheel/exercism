defmodule NucleotideCount do
  @nucleotides [?A, ?C, ?G, ?T]
  @nucleotides_histogram %{?A => 0, ?C => 0, ?G => 0, ?T => 0}
  @doc """
  Counts individual nucleotides in a DNA strand.

  ## Examples

  iex> NucleotideCount.count('AATAA', ?A)
  4

  iex> NucleotideCount.count('AATAA', ?T)
  1
  """
  @spec count([char], char) :: non_neg_integer
  def count(strand, nucleotide) do
    strand |> Enum.count(&(&1 == nucleotide))
  end

  @doc """
  Returns a summary of counts by nucleotide.

  ## Examples

  iex> NucleotideCount.histogram('AATAA')
  %{?A => 4, ?T => 1, ?C => 0, ?G => 0}
  """
  @spec histogram([char]) :: map
  def histogram(strand) do
    strand |> Enum.reduce( @nucleotides_histogram, fn c, count -> Map.update(count, c, 1, &(&1 + 1)) end )
  end
end
