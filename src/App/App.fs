module App

open Sutil
open Sutil.DOM
open Sutil.Styling
open Feliz
open Sutil.DOM.CssRules
open Sutil.Bulma.Helpers
open Feliz.Engine
open Sutil
open Sutil.Attr


// Start the app
Main.view.view() |> mountElement "sutil-app"