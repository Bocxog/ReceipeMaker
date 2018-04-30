namespace ReceipeMaker
open Receipe.Data
open System.ComponentModel
module Say =
    let m2 = Receipe.Data.DbContextFactory
    let m3 = m2().CreateDbContext
    
    let m (db:Receipe.Data.DataContext) = db.Receipes |> Seq.iter(fun i -> printfn "%s" i.Name)
    //let res = m2.Receipes |> List.filter(fun i -> true)
    //+ (res |> List.length)
    let hello name =
        printfn "Hello %s" name
