defmodule BinarySearch do
  @doc """
    Searches for a key in the tuple using the binary search algorithm.
    It returns :not_found if the key is not in the tuple.
    Otherwise returns {:ok, index}.

    ## Examples

      iex> BinarySearch.search({}, 2)
      :not_found

      iex> BinarySearch.search({1, 3, 5}, 2)
      :not_found

      iex> BinarySearch.search({1, 3, 5}, 5)
      {:ok, 2}

  """

  @spec search(tuple, integer) :: {:ok, integer} | :not_found
  def search({}, _key), do: :not_found
  def search(numbers, key) when is_tuple(numbers), do: search(Tuple.to_list(numbers), key)
  def search(numbers, key) when is_list(numbers) do
    
    mid = div(length(numbers), 2)
    
    {upper_half, lower_half } = Enum.split(numbers, mid)

    guess = (List.last(upper_half) || List.first(lower_half) )
    cond do 
      List.first(numbers) < key -> 
        :not_found
      List.last(numbers) > key ->
        :not_found
      key < guess && length(upper_half) > 0 ->
        search(upper_half, key)
      key > guess && length(lower_half) > 0 ->
        search(lower_half, key)
      key == guess ->
        guess
      :else ->
        :not_found
    end
  end

end
