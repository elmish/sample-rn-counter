module internal Styles

open Fable.Helpers.ReactNative
open Fable.Helpers.ReactNative.Props

let [<Literal>] brandPrimary = "#428bca"
let [<Literal>] brandInfo = "#5bc0de"
let [<Literal>] brandSuccess = "#5cb85c"
let [<Literal>] brandDanger = "#d9534f"
let [<Literal>] brandWarning = "#f0ad4e"
let [<Literal>] brandSidebar = "#252932"

let [<Literal>] inverseTextColor = "#000"

let [<Literal>] textColor = "#FFFFFF"

let [<Literal>] shadowColor = "#000000"

let [<Literal>] backgroundColor = "#615A5B"
let [<Literal>] inputBackgroundColor = "#251D1C"

let [<Literal>] touched = "#5499C4"

let [<Literal>] fontSizeBase = 15.
let [<Literal>] titleFontSize = 17.

let [<Literal>] borderRadius = 4.

let buttonStyle<'a> =
    TouchableHighlightProperties.Style [
        BackgroundColor brandPrimary
        BorderRadius borderRadius
        Margin 5.
      ]

let defaultText<'a> =
    TextProperties.Style [ 
        Color textColor
        TextAlign TextAlignment.Center
        Margin 5.
        FontSize fontSizeBase
      ]

let titleText<'a> =
    TextProperties.Style [ 
        Color textColor
        TextAlign TextAlignment.Center
        Margin 15.
        FontSize titleFontSize
      ] 

let sceneBackground<'a> =
    ViewProperties.Style [ 
        AlignSelf Alignment.Stretch
        Padding 20.
        ShadowColor shadowColor
        ShadowOpacity 0.8
        ShadowRadius 3.
        JustifyContent JustifyContent.Center
        Flex 1.
        BackgroundColor backgroundColor
      ]

let button label onPress =
    text [ defaultText ] label
    |> touchableHighlightWithChild [
        buttonStyle
        TouchableHighlightProperties.UnderlayColor touched
        OnPress onPress]

let verticalButton label onPress =
    text [ defaultText ] label
    |> touchableHighlightWithChild [
        TouchableHighlightProperties.Style [
            BackgroundColor brandPrimary
            BorderRadius borderRadius
            Margin 5.
            Padding 5.
        ]
        TouchableHighlightProperties.UnderlayColor touched
        OnPress onPress]