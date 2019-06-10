defmodule Mastermind.Strategy do
  @moduledoc """
  Break the code using Knuth's Algorithm
  """

  alias Mastermind.Game
  alias Mastermind.Core

  @colours [:red, :blue, :green, :black, :orange, :yellow]

  @possible_scores %{
    {0,0} => 0,
    {0,1} => 0,
    {0,2} => 0,
    {0,3} => 0,
    {0,4} => 0,
    {1,0} => 0,
    {1,1} => 0,
    {1,2} => 0,
    {1,3} => 0,
    {2,0} => 0,
    {2,1} => 0,
    {2,2} => 0,
    {3,0} => 0,
    {4,0} => 0,
  }

  @max_moves 12

  @doc """
  Solve new game
  """
  def break_code(%{guesses: []} = game) do
    g = Game.guess(game, [:red, :red, :green, :green])
    loop_while(g, guess_combinations(), Game.won?(g), @max_moves)
  end

  @doc """
  Solve partially completed game
  """
  def break_code(game) do
    loop_while(game, guess_combinations(), Game.won?(game), @max_moves)
  end

  def guess_combinations() do
    for w <- @colours,
        x <- @colours,
        y <- @colours,
        z <- @colours, do: [w,x,y,z]
  end

  defp loop_while(game, _matches, true = _won, _) do
    {:won, game}
  end

  defp loop_while(game, _matches, false = _won, 1) do
    {:lost, game}
  end

  defp loop_while(game, matches, false = _won, moves_left) do
    matches = guess_matches(game, matches)
    next_guess = next_guess(matches)
    game = Game.guess(game, next_guess)
    loop_while(game, matches, Game.won?(game), moves_left - 1)
  end

  defp guess_matches(game, matches) do
    Enum.filter(matches, &(Core.score(Game.current_guess?(game), &1) == Game.score?(game)))
  end

  def next_guess(match) do
    next_guesses = min_max(match)

    next_guess = MapSet.intersection(MapSet.new(match), MapSet.new(next_guesses)) |> MapSet.to_list()

    if Enum.empty?(next_guess) do
      next_guesses
    else
      next_guess
    end
    |> List.first()
  end

  def min_max(matches) do
    scores = guess_combinations() |> Enum.map(fn combination ->
      {_max_score, max_count} = max_score(combination, matches)
      {combination, max_count}
    end)

    {_, min} = Enum.min_by(scores, fn {_combination, max_count} -> max_count end)

    scores
    |> Enum.filter(fn {_combination, count} -> count == min end)
    |> Enum.map(fn {combination, _count} -> combination end)
  end

  def max_score(combination, matches) do
    Enum.reduce(matches, @possible_scores, fn x, acc ->
      %{red: red, white: white} = Core.score(combination, x)
      count = Map.get(acc, {red, white})
      %{acc | {red, white} => count + 1}
    end)
    |> Enum.max_by(fn {_score, count} -> count end)
  end
end
