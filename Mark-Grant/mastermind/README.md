# Mastermind - Code Breaker

Breaks the code using Knuth's Algorithm

Solution by Mark Spink  & Grant Crofton

## Running the code in the elixir repl

```
iex> Mastermind.Game.new([:red, :red, :blue, :blue]) |> Mastermind.Strategy.break_code
{:won,
 %Mastermind.Game{
   code: [:red, :red, :blue, :blue],
   guesses: [
     {[:red, :red, :blue, :blue], %{red: 4, white: 0}},
     {[:red, :orange, :blue, :red], %{red: 2, white: 1}},
     {[:red, :blue, :red, :black], %{red: 1, white: 2}},
     {[:red, :red, :green, :green], %{red: 2, white: 0}}
   ]
 }}
```

The code was solved in 4 guesses.
