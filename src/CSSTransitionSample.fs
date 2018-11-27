module CSSTransitionSample

open Fable.Core.JsInterop
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.React.TransitionGroup

type CSSTransitionSampleState = {
    name: string
    showValidationMessage: bool
    showValidationButton: bool
}
        
type CSSTransitionSample (props) =
    inherit Component<unit, CSSTransitionSampleState>(props)
    do base.setInitState({
        name = ""
        showValidationMessage = false
        showValidationButton = false
    })
    override self.render () =
        div [ Class "card" ] [
            div [ Class "card-body" ] [
                yield h4 [ Class "card-title" ] [
                    str "CSSTransition sample"
                ]
                yield form [] [
                    div [ Class "form-group" ] [
                        label [ HtmlFor "text" ] [ str "Your name" ]
                        input [
                            Id "text"
                            Class "input-block"
                            Type "text"
                            Value self.state.name
                            OnFocus (fun _ ->
                                self.setState(fun state _ -> {
                                    state with
                                        showValidationMessage = false
                                })
                            )
                            OnChange (fun e ->
                                let target = e.target
                                self.setState(fun state _ -> {
                                    state with
                                        name = target?value
                                        showValidationButton = true
                                })
                            )
                        ]
                    ]
                    cssTransitionWithRender [
                        In self.state.showValidationMessage
                        Timeout !^300
                        ClassNames !^"message"
                        UnmountOnExit true
                        OnExited (fun _ ->
                            self.setState(fun state _ -> {
                                state with
                                    showValidationButton = true
                            })
                        )
                    ] (fun state ->
                        ReactNode.Case1 (
                            ReactChild.Case1 (
                                div [
                                    Class "help-block"
                                ] [
                                    str "Your name rocks!"
                                    cssTransition [
                                        In (state = Entered)
                                        Timeout !^300
                                        ClassNames !^"star"
                                        UnmountOnExit true
                                    ] (
                                        div [ Class "star" ] [
                                            str "⭐"
                                        ]
                                    )
                                ]
                            )
                        )
                    )
                ]
                if self.state.showValidationButton then
                    yield button [
                        OnClick (fun _ ->
                            self.setState(fun state _ -> {
                                state with
                                    showValidationButton = false
                                    showValidationMessage = true
                            })
                        )
                    ] [
                        str "Validate form"
                    ]
            ]
        ]

let cssTransitionSample () =
    ofType<CSSTransitionSample, _, CSSTransitionSampleState> () []
