module TransitionGroupSample

open Fable.Core.JsInterop
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.React.TransitionGroup

type Item = {
    id: System.Guid
    text: string
}

type TransitionGroupSampleState = {
    items: Item list
}

type TransitionGroupSample (props) =
    inherit Component<unit, TransitionGroupSampleState>(props)
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
                ol [] [
                    transitionGroup [
                        TransitionGroupProps.Custom("className", "todo-list")
                    ] [
                        for item in self.state.items ->
                            cssTransition [
                                CSSTransitionProps.Key (string item.id)
                                Timeout !^500
                                ClassNames !^"fade"
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
                        let text = Fable.Import.Browser.window.prompt("Enter some text")
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
