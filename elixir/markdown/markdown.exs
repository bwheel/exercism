defmodule Markdown do
  @doc """
    Parses a given string with Markdown syntax and returns the associated HTML for that string.

    ## Examples

    iex> Markdown.parse("This is a paragraph")
    "<p>This is a paragraph</p>"

    iex> Markdown.parse("#Header!\n* __Bold Item__\n* _Italic Item_")
    "<h1>Header!</h1><ul><li><em>Bold Item</em></li><li><i>Italic Item</i></li></ul>"
  """
  @spec parse(String.t()) :: String.t()
  def parse(m) do
    m
    |> String.split("\n")
    |> Enum.map(fn text -> apply_line_markdown(text) end)
    |> Enum.join
    |> patch
  end
  
  defp apply_line_markdown("#" <> text), do: "#" <> text |> apply_header_markdown 
  defp apply_line_markdown("*" <> text), do: "*" <> text |> apply_list_markdown
  defp apply_line_markdown(text), do: text |>  apply_paragraph_markdown  

  defp apply_header_markdown(line) do
    # 1. Extract the leading #'s to count the level
    [head | tail] = String.split(line)
    
    # 2. count the header level
    level = head
    |> String.length
    |> to_string

    # 3. enclose with header tag.
    tail
    |> Enum.join(" ")
    |> enclose_with_tag("h" <> level)
  end

  defp apply_list_markdown(line) do
    line
    |> String.trim_leading("* ")
    |> apply_inline_markdown
    |> enclose_with_tag("li")
  end

  defp apply_paragraph_markdown(line) do
    line
    |> apply_inline_markdown
    |> enclose_with_tag("p")
  end

  defp apply_inline_markdown(line) do
    line
      |> String.split
      |> Enum.map(
        fn word -> word
            |> replace_prefix_markdown
            |> replace_suffix_markdown
            end)
      |> Enum.join(" ")
  end

  defp enclose_with_tag(content, tag), do: "<#{tag}>#{content}</#{tag}>"
  
  defp replace_prefix_markdown(word) do
    cond do
      word =~ ~r/^#{"__"}{1}/ -> String.replace(word, ~r/^#{"__"}{1}/, "<strong>", global: false)
      word =~ ~r/^[#{"_"}{1}][^#{"_"}+]/ -> String.replace(word, ~r/_/, "<em>", global: false)
      true -> word
    end
  end

  defp replace_suffix_markdown(word) do
    cond do
      word =~ ~r/#{"__"}{1}$/ -> String.replace(word, ~r/#{"__"}{1}$/, "</strong>")
      word =~ ~r/[^#{"_"}{1}]/ -> String.replace(word, ~r/_/, "</em>")
      true -> word
    end
  end

  defp patch(l) do
    String.replace_suffix(
      String.replace(l, "<li>", "<ul><li>", global: false),
      "</li>",
      "</li></ul>"
    )
  end
end
