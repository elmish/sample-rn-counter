module AwesomeApp


open Elmish

// MODEL

type Model = int


type Msg =
  | Increment
  | Decrement


let init () =
  0


// UPDATE

let update (msg:Msg) count =
  match msg with
  | Increment ->
      count + 1

  | Decrement ->
      count - 1


// rendering views with ReactNative
module R = Fable.Helpers.ReactNative

let view count (dispatch:Dispatch<Msg>) =
  let onClick msg =
    fun () -> msg |> dispatch 

  R.view [Styles.sceneBackground]
    [ Styles.button "-" (onClick Decrement)
      R.text [] (string count)
      Styles.button "+" (onClick Increment) ]

open Elmish.ReactNative
open Elmish.HMR

// App
Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withHMR
|> Program.withReactNative "counter"
|> Program.run
