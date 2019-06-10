defmodule MastermindStrategyTest do
  use ExUnit.Case

  alias Mastermind.Game
  alias Mastermind.Strategy

  test "new game solve in one guesses" do
    Game.new([:red, :red, :green, :green])
    |> Strategy.break_code()
    |> assert_won(1)
  end

  test "new game solve in four guesses" do
    Game.new([:red, :green, :black, :blue])
    |> Strategy.break_code()
    |> assert_won(5)
  end

  test "solve partially played game" do
    Game.new([:red, :green, :black, :blue])
    |> Game.guess([:black, :yellow, :orange, :blue])
    |> Game.guess([:blue, :yellow, :orange, :black])
    |> Game.guess([:green, :yellow, :black, :blue])
    |> Strategy.break_code()
    |> assert_won(5)
  end

  def assert_won({outcome, game}, moves) do
    assert outcome == :won
    assert Game.moves?(game) == moves
  end
end
