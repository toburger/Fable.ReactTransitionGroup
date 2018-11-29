module StaggeredChildAnimationSample

open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.React.TransitionGroup

let staggeredListSample () =
    let items = [1..15]
    div [ Class "card" ] [
        div [ Class "card-body" ] [
            h4 [ Class "card-title" ] [
                str "Staggered Child Animation sample"
            ]
            h6 [ Class "card-subtitle" ] [
                a [ Href "https://github.com/toburger/Fable.React.TransitionGroup.Samples/blob/master/src/StaggeredChildAnimationSample.fs" ] [
                    str "Link to F# code"
                ]
                a [ Href "https://codepen.io/cheryllaird/pen/OXVpVv" ] [
                    str "Link to original JavaScript code"
                ]
            ]
            transitionGroup [
                TransitionGroupProp.Appear true
                TransitionGroupProp.Component !^"ol"
                TransitionGroupProp.Class "list"
            ] [
                for i, item in List.indexed items ->
                    cssTransition [
                        CSSTransitionProp.Key (string i)
                        CSSTransitionProp.Timeout !^(1000 * (i + 1))
                        CSSTransitionProp.ClassNames !^"slide-up"
                    ] (
                        li [
                            Class "list-item"
                            Style [
                                TransitionDelay (sprintf "%fs" (float i * 0.05))
                            ]
                        ] [ str (string item) ]
                    )
            ]
        ]
    ]
