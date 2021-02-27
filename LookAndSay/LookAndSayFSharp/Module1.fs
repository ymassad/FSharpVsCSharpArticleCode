namespace LookAndSayFSharp

module Module1 =
    type Group = {digit : char; count : int}

    let lookAndSay (str:string) =
        let stringDigits = str |> Seq.toList

        let incrementCount group = {group with count = group.count + 1};

        let rec getOneGroup nonEmptyDigits = 
            match nonEmptyDigits with
                | x :: y :: rest when x = y -> getOneGroup(y :: rest) |> incrementCount
                | x :: _ -> { digit = x; count = 1}

        let getOneGroupAndRemainingDigits digits =
            match digits with
                | [] -> None
                | _ ->
                    let group = getOneGroup digits
                    Some(group, digits |> List.skip group.count)

        let encodeGroup group = group.count.ToString() + group.digit.ToString()

        stringDigits
            |> Seq.unfold getOneGroupAndRemainingDigits
            |> Seq.map encodeGroup
            |> String.concat ""