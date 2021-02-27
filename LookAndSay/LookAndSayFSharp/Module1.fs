namespace LookAndSayFSharp

module Module1 =
    type Group = {character : char; count : int}

    let incrementCount group = {group with count = group.count + 1};

    let encodeGroup group = group.count.ToString() + group.character.ToString()

    let lookAndSay (str:string) =
        let stringChars = str |> Seq.toList

        let rec getOneGroup nonEmptyChars = 
            match nonEmptyChars with
                | x :: y :: z when x = y -> getOneGroup(y :: z) |> incrementCount
                | x :: _ -> { character = x; count = 1}

        let getOneGroupAndRemainingChars chars =
            match chars with
                | [] -> None
                | _ ->
                    let group = getOneGroup chars
                    Some(group, chars |> List.skip group.count)

        stringChars
            |> Seq.unfold getOneGroupAndRemainingChars
            |> Seq.map encodeGroup
            |> String.concat ""