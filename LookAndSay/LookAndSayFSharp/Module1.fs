namespace LookAndSayFSharp

module Module1 =
    type Group = {digit : char; count : int}

    let incrementCount group = {group with count = group.count + 1};

    let encodeGroup group = group.count.ToString() + group.digit.ToString()

    let lookAndSay (str:string) =
        let stringDigits = str |> Seq.toList

        let rec getOneGroup nonEmptyDigits = 
            match nonEmptyDigits with
                | x :: y :: z when x = y -> getOneGroup(y :: z) |> incrementCount
                | x :: _ -> { digit = x; count = 1}

        let getOneGroupAndRemainingDigits digits =
            match digits with
                | [] -> None
                | _ ->
                    let group = getOneGroup digits
                    Some(group, digits |> List.skip group.count)

        stringDigits
            |> Seq.unfold getOneGroupAndRemainingDigits
            |> Seq.map encodeGroup
            |> String.concat ""