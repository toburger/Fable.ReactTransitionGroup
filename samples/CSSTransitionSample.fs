module CSSTransitionSample

open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Fable.ReactTransitionGroup

importSideEffects "./CSSTransitionSample.css"

type CSSTransitionSampleState = {
    name: string
    showValidationMessage: bool
    showValidationButton: bool
}
        
type CSSTransitionSample (props) =
    inherit Component<obj, CSSTransitionSampleState>(props)
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
                yield h6 [ Class "card-subtitle" ] [
                    a [ Href "https://github.com/toburger/Fable.ReactTransitionGroup/blob/master/samples/CSSTransitionSample.fs" ] [
                        str "Link to F# code"
                    ]
                    a [ Href "https://codesandbox.io/s/m77l2vp00x" ] [
                        str "Link to original JavaScript code"
                    ]
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
                        CSSTransitionProp.In self.state.showValidationMessage
                        CSSTransitionProp.Timeout !^300
                        CSSTransitionProp.ClassNames !^"message"
                        CSSTransitionProp.UnmountOnExit true
                        CSSTransitionProp.OnExited (fun _ ->
                            self.setState(fun state _ -> {
                                state with
                                    showValidationButton = true
                            })
                        )
                    ] (fun state ->
                        div [
                            Class "help-block"
                        ] [
                            str "Your name rocks!"
                            cssTransition [
                                CSSTransitionProp.In (state = Entered)
                                CSSTransitionProp.Timeout !^300
                                CSSTransitionProp.ClassNames !^"star"
                                CSSTransitionProp.UnmountOnExit true
                            ] (
                                div [ Class "star" ] [
                                    str "⭐"
                                ]
                            )
                        ]
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
