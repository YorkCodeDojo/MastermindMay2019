defmodule MastermindCoreTest do
  use ExUnit.Case

  alias Mastermind.Core

  test "score for no colour and no position matches" do
    assert Core.score([:red, :red, :red, :red], [:green, :green, :green, :green]) == %{red: 0, white: 0}
  end

  test "score for no colour and one position matches" do
    assert Core.score([:red, :red, :red, :red], [:red, :blue, :blue, :blue]) == %{red: 1, white: 0}
  end

  test "score for one colour no position matches" do
    assert Core.score([:red, :red, :red, :green], [:blue, :blue, :green,  :blue]) == %{red: 0, white: 1}
  end

  test "score for two colour no position matches" do
    assert Core.score([:red, :red, :red, :green], [:green, :blue, :green,  :blue]) == %{red: 0, white: 1}
  end

  test "score for one colour and one position matches" do
    assert Core.score([:blue, :red, :red, :green], [:blue, :blue, :green,  :blue]) == %{red: 1, white: 1}
  end
end
