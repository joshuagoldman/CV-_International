module Main.types

type Msg =
    | Main_Msg_Async of Async<Msg>

type Model = {
    Name: string
}

