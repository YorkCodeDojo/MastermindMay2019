defmodule Mastermind.Game do

  alias Mastermind.Core

  defstruct(
    code: [],
    guesses: []
  )

  def new(code) do
    %__MODULE__{
      code: code
    }
  end

  def guess(game, guess) do
    %{
      game
      | guesses: [ {guess, Core.score(game.code, guess)} | game.guesses]
    }
  end

  def current_guess?(%{guesses: []}) do
    []
  end

  def current_guess?(%{guesses: guesses}) do
    {guess, _} = List.first(guesses)
    guess
  end

  def score?(%{guesses: []}) do
    %{red: 0, white: 0}
  end

  def score?(%{guesses: guesses}) do
    {_, score} = List.first(guesses)
    score
  end

  def won?(game) do
    score?(game) == %{red: 4, white: 0}
  end

  def moves?(game) do
    Enum.count(game.guesses)
  end
end
