module TransitionGroupSample

open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Fable.ReactTransitionGroup

importSideEffects "./TransitionGroupSample.css"

type Item = {
    id: System.Guid
    text: string
}

type TransitionGroupSampleState = {
    items: Item list
}

type TransitionGroupSample (props) =
    inherit Component<obj, TransitionGroupSampleState>(props)
    do base.setInitState({
        items = [
            { id = System.Guid.NewGuid(); text = "Buy eggs" }
            { id = System.Guid.NewGuid(); text = "Pay bills" }
            { id = System.Guid.NewGuid(); text = "Invite friends over" }
            { id = System.Guid.NewGuid(); text = "Fix the TV" }
        ]
    })
    override self.render () =
        div [ Class "card" ] [
            div [ Class "card-body" ] [
                h4 [ Class "card-title" ] [
                    str "TransitionGroup sample"
                ]
                h6 [ Class "card-subtitle" ] [
                    a [ Href "https://github.com/toburger/Fable.ReactTransitionGroup/blob/master/samples/TransitionGroupSample.fs" ] [
                        str "Link to F# code"
                    ]
                    a [ Href "https://codesandbox.io/s/00rqyo26kn" ] [
                        str "Link to original JavaScript code"
                    ]
                ]
                ol [
                    Style [
                        ListStyleType "none"
                        Padding 0
                    ]
                ] [
                    transitionGroup [
                        TransitionGroupProp.Class "todo-list"
                    ] [
                        for item in self.state.items ->
                            cssTransition [
                                CSSTransitionProp.Key (string item.id)
                                CSSTransitionProp.Timeout !^500
                                CSSTransitionProp.ClassNames !^"fade"
                            ] (
                                li [] [
                                    button [
                                        Type "button"
                                        Class "btn-small remove-btn"
                                        OnClick (fun _ ->
                                            self.setState(fun state _ -> {
                                                state with
                                                    items =
                                                        state.items
                                                        |> List.filter (fun i ->
                                                            i.id <> item.id)
                                            })
                                        )
                                    ] [ str "X" ]
                                    str item.text
                                ]
                            )
                    ]
                ]
                button [
                    Type "button"
                    OnClick (fun _ ->
                        let text = Browser.Dom.window.prompt("Enter some text")
                        if not (System.String.IsNullOrEmpty text) then
                            self.setState(fun state _ -> {
                                state with
                                    items =
                                        state.items @ [
                                            { id = System.Guid.NewGuid()
                                              text = text }
                                        ]
                            })
                    )
                ] [ str "Add item" ]
            ]
        ]

let transitionGroupSample () =
    ofType<TransitionGroupSample, _, TransitionGroupSampleState> () []
