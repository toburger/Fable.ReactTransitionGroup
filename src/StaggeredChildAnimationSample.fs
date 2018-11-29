module StaggeredChildAnimationSample

open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.ReactTransitionGroup

importSideEffects "./StaggeredChildAnimationSample.css"

let staggeredListSample () =
    let items = [1..15]
    div [ Class "card" ] [
        div [ Class "card-body" ] [
            h4 [ Class "card-title" ] [
                str "Staggered Child Animation sample"
            ]
            h6 [ Class "card-subtitle" ] [
                a [ Href "https://github.com/toburger/Fable.ReactTransitionGroup.Samples/blob/master/src/StaggeredChildAnimationSample.fs" ] [
                    str "Link to F# code"
                ]
                a [ Href "https://codepen.io/cheryllaird/pen/OXVpVv" ] [
                    str "Link to original JavaScript code"
                ]
            ]
            transitionGroup [
                TransitionGroupProp.Appear true
                TransitionGroupProp.Class "list child-borders"
            ] [
                for i, item in List.indexed items ->
                    cssTransition [
                        CSSTransitionProp.Key (string i)
                        CSSTransitionProp.Timeout !^(100 * (i + 5))
                        CSSTransitionProp.ClassNames !^"slide-up"
                    ] (
                        div [
                            Class "list-item background-secondary"
                            Style [
                                TransitionDelay (sprintf "%fs" (float i * 0.05))
                            ]
                        ] [ str (string item) ]
                    )
            ]
        ]
    ]
