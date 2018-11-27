module App

open Fable.Helpers.React

let renderApp () =
    mountById "container1"
        <| TransitionSample.transitionSample ()
    mountById "container2"
        <| CSSTransitionSample.cssTransitionSample ()
    mountById "container3"
        <| TransitionGroupSample.transitionGroupSample ()

renderApp ()