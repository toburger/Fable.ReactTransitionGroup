module App

open Fable.Helpers.React
open Fable.Helpers.React.Props

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
        blockquote [] [
            str "Samples ported from the "
            a [ Href "http://reactcommunity.org/react-transition-group/" ] [
                str "React Transition Group homepage"
            ]
        ]
    ]

renderApp ()
|> mountById "app"
