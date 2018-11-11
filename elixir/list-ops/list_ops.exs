defmodule ListOps do
  # Please don't use any external modules (especially List) in your
  # implementation. The point of this exercise is to create these basic functions
  # yourself.
  #
  # Note that `++` is a function from an external module (Kernel, which is
  # automatically imported) and so shouldn't be used either.

  @spec count(list) :: non_neg_integer
  def count(l), do: count(l, 0)
  defp count([], size), do: size
  defp count([_head | tail], size), do: count(tail, size + 1)
  
  @spec reverse(list) :: list
  def reverse(l), do: reverse(l, [])
  defp reverse([head|tail], result), do: reverse(tail, [head | result ])
  defp reverse([], result), do: result
  
  @spec map(list, (any -> any)) :: list
  def map([], _f), do: []
  def map([head|tail], f), do: [f.(head)| map(tail, f)]
  
  @spec filter(list, (any -> as_boolean(term))) :: list
  def filter([], _f), do: []
  def filter([head|tail], f) do
    case f.(head) do
      true -> [head | filter(tail, f)]
      _ -> filter(tail, f)
    end
  end
  
  @type acc :: any
  @spec reduce(list, acc, (any, acc -> acc)) :: acc
  def reduce([], acc, _f), do: acc
  def reduce([head|tail], acc, f), do: reduce(tail, f.(head, acc), f) 

  @spec append(list, list) :: list
  def append([], []), do: []
  def append([], b), do: b
  def append([head|tail], b), do: [head | append( tail, b ) ]

  @spec concat([[any]]) :: [any]
  def concat(list) when list == [], do: []
  def concat(list), do: concat(list, []) |> reverse
  def concat([head | tail], acc) when head == [], do: concat(tail, acc)
  def concat([head | tail], acc) when is_list(head),  do: concat(tail, concat(head, acc) )
  def concat([head | tail], acc), do: concat(tail, [head | acc])
  def concat(_list, acc), do: acc
end
