defmodule Mastermind.Core do
  @number_of_pins 4

  def score(code, guess) do
    %{
      red: well_placed_colours(code, guess),
      white: misplaced_colours(code, guess)
    }
  end

  defp well_placed_colours(code, guess) do
    guess
    |> Enum.zip(code)
    |> Enum.count(&same?/1)
  end

  defp same?({x,y}), do: x == y

  defp misplaced_colours(code, guess) do
     matching_colours(code, guess) - well_placed_colours(code, guess)
  end

  defp matching_colours(code, guess) do
    @number_of_pins - Enum.count(code -- guess)
  end
end
