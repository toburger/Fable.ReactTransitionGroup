module App

open Fable.React
open Fable.React.Props

let renderApp () =
    div [] [
        div [ Class "margin" ] [
            TransitionSample.transitionSample ()
        ]
        div [ Class "margin" ] [
            CSSTransitionSample.cssTransitionSample ()
        ]
        div [ Class "margin" ] [
            TransitionGroupSample.transitionGroupSample ()
        ]
        div [ Class "margin" ] [
            StaggeredChildAnimationSample.staggeredListSample ()
        ]
        blockquote [] [
            str "Samples ported from the "
            a [ Href "http://reactcommunity.org/react-transition-group/" ] [
                str "React Transition Group homepage"
            ]
        ]
    ]

renderApp ()
|> Helpers.mountById "app"
