module TransitionSample

open Fable.Core.JsInterop
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactTransitionGroup

type TransitionSampleState = {
    show: bool
    entered: bool
}

type TransitionSample (props) =
    inherit Component<unit, TransitionSampleState>(props)
    do base.setInitState({ show = false; entered = false })
    override self.render() =
        div [ Class "card" ] [
            div [ Class "card-body" ] [
                h4 [ Class "card-title" ] [
                    str "Transition sample"
                ]
                h6 [ Class "card-subtitle" ] [
                    a [ Href "https://github.com/toburger/Fable.React.TransitionGroup.Samples/blob/master/src/TransitionSample.fs" ] [
                        str "Link to F# code"
                    ]
                    a [ Href "https://codesandbox.io/s/741op4mmj0" ] [
                        str "Link to original JavaScript code"
                    ]
                ]
                div [ Class "row flex-middle" ] [
                    div [] [
                        button [
                            OnClick (fun _ ->
                                self.setState(fun state _ ->
                                    { state with show = not state.show }
                                )
                            )
                        ] [ str "Toggle "]
                    ]
                    div [ Class "col-fill col" ] [
                        transitionWithRender [
                            TransitionProp.In self.state.show
                            TransitionProp.Timeout !^1000
                            TransitionProp.UnmountOnExit true
                        ] (function
                            | Entering -> str "Entering..."
                            | Entered -> str "Entered!"
                            | Exiting -> str "Exiting..."
                            | Exited -> str "Exited!"
                            | Unmounted -> null)
                    ]
                ]
            ]
        ]

let transitionSample () =
    ofType<TransitionSample, _, TransitionSampleState> () []
