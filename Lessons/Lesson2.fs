(*Basic function*)
let lowerThan = fun numbers ->
  let n1, n2 = numbers
  n1 < n2
printfn "%b" (lowerThan(9, 4))

(* Tuple *)
let add = fun numbers ->
  let n1, n2 = numbers
  n1 + n2
printfn "%d" (add(4, 5))

(*Currying*)
let addCurrying = fun x ->
  let add' = fun y -> x + y
  add'

let add5 = addCurrying 5
let fifteen = add5 10
printf "%d" (addCurrying 5 10)


(*Discriminated Union*)
type Person =
  | Employee of string * string * string  (*string string string = tuple*)
  | Customer of string

let paul = Employee ("toto", "tata", "012358965")
let darty = Customer "darty"

(*List*)
type ListInt =
  | Empty
  | Item of int * ListInt

let l1 = Item(1, Item(2, Item(3, Empty)))
let l2 = Item(4, l1)

let removeFirst = fun l ->
  match l with
  | Empty -> Empty
  | Item( _, sublist) -> sublist

let l3 =removeFirst l1

(*Generic List*)
type List<'T> =
| Empty
| Item of 'T * List<'T>

let persons = Item(Customer("Darty"), Item(Customer("Fnac"), Empty))
let l4 = Item(1, Item(2, Item(3, Empty)))

let l5 = Item("Titi", Item("Toto", Empty))
let addHead = fun item -> fun list -> Item(item, list)
let l6 = addHead "Tutu" l5

let rec addTail = fun item -> fun list ->
  match item with
  | Empty -> Item(item, Empty)
  | Item(head, tail) -> addTail item tail