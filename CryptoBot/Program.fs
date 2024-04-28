namespace CryptoBot

open TradingLib


module Program =

    [<EntryPoint>]
    let main _: int = Log.Info("Run", "Run") ; 0



    (*
    let Main (param: struct {| StartTime: System.DateTime
                               EndTime: System.DateTime
                               ClientFunction: unit -> Client
                               StrategyFunction: Client -> Strategy |}): int =

        let execute (client: Client): bool =
            let info = client.GetAccountInfo()
            match info.Total with
            | No -> Log.Error("Execute", "Failed to obtain account info")
            | Yes(initial) ->
                Log.Info("Execute", $"Obtained initial balance as {initial}")
                client.CancelAllOrders() |> ignore
                let start = param.StartTime.ToString("F")
                Log.Info("Execute", $"Waiting for starting time of {start}")
                while not(Utils.Elapsed param.StartTime) do (Utils.Wait delay)
                let strategy: Strategy  = param.StrategyFunction client
                if client.Stream(delay) then
                    Log.Info("Execute", "Streaming all data") ; strategy.Run(initial)
                else
                    Log.Error("Execute", "Trading bot failed to stream data!")

        Log.Info("Execute", $"Trading bot starting at {Utils.CurrentTime()}")
        let client = param.ClientFunction ()
        let result: bool = try (execute client) finally client.Dispose()
        Log.Info("Execute", $"Trading bot ended at {Utils.CurrentTime()}!")
        if result then 0 else 1


let size = 10
let data = Vector.Buffer(size, fun _ -> Bar())

let tickers: Ticker list = [ Crypto("BTC") ]

let source: Data.Source = Gemini.Source {|
    Tickers = tickers
    Size = size
    Buffer = Buffer.Linear(1L, 5)
    AskBidDifference = 0.15
    Timeout = 5 |}

for i = 1 to 10 do
    printfn $" ***** {i} *****"
    let b = source.Data[Crypto("BTC")].Get(data)
    if b then
        for i in [1 .. size] do printfn "Output -> %A" data[i-1]
    else printfn "SKIP"
    Utils.Wait(5)
*)
