defmodule MastermindGameTest do
  use ExUnit.Case

  alias Mastermind.Game

  test "game" do
    Game.new([:red, :blue, :red, :green])
    |> assert_field_value(:code, [:red, :blue, :red, :green])
    |> assert_condition(&Game.current_guess?/1, [])
    |> assert_condition(&Game.score?/1, %{red: 0, white: 0})
    |> assert_condition(&Game.won?/1, false)
    |> assert_condition(&Game.moves?/1, 0)
    |> Game.guess([:red, :green, :green, :black])
    |> assert_condition(&Game.current_guess?/1, [:red, :green, :green, :black])
    |> assert_condition(&Game.score?/1, %{red: 1, white: 1})
    |> assert_condition(&Game.won?/1, false)
    |> assert_condition(&Game.moves?/1, 1)
    |> Game.guess([:red, :blue, :green, :black])
    |> assert_condition(&Game.current_guess?/1, [:red, :blue, :green, :black])
    |> assert_condition(&Game.score?/1, %{red: 2, white: 1})
    |> assert_condition(&Game.won?/1, false)
    |> assert_condition(&Game.moves?/1, 2)
    |> Game.guess([:red, :blue, :red, :green])
    |> assert_condition(&Game.current_guess?/1, [:red, :blue, :red, :green])
    |> assert_condition(&Game.score?/1, %{red: 4, white: 0})
    |> assert_condition(&Game.won?/1, true)
    |> assert_condition(&Game.moves?/1, 3)
  end

  def assert_field_value(game, field, expected) do
    assert Map.get(game, field) == expected
    game
  end

  def assert_condition(game, condition_fn, expected) do
    assert condition_fn.(game) == expected
    game
  end
end
