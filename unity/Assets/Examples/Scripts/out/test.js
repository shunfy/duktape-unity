function Other() {

}

function FooBase() {
    console.log("FooBase")
}

FooBase.base_s = function () {
    console.log("FooBase.base_s")
}

FooBase.prototype.play = function () {
    console.log("FooBase.play")
}

function Foo() {
    FooBase.call(this)
    console.log("Foo")
}

Foo.sub_s = function () {
    console.log("Foo.sub_s")
}

// function __() {
//     console.log("dummy function")
// }
// __.prototype = FooBase.prototype
// Foo.prototype = new __()
Foo.prototype = Object.setPrototypeOf({}, FooBase.prototype)
Foo.prototype.say = function () {
    console.log("Foo.say")
}

var foo = new Foo()
foo.say()
foo.play()
var fooBase = new FooBase()
fooBase.play()

console.log("*** instanceof checking")
console.log("foo instanceof Foo: ", foo instanceof Foo)
console.log("foo instanceof FooBase: ", foo instanceof FooBase)
console.log("foo instanceof Other: ", foo instanceof Other)
console.log("fooBase instanceof Foo: ", fooBase instanceof Foo)
console.log("fooBase instanceof FooBase: ", fooBase instanceof FooBase)
console.log("fooBase instanceof Other: ", fooBase instanceof Other)

console.log("*** instance proto")
console.log(new FooBase().__proto__)
console.log(Foo.__proto__)
console.log(Foo.prototype)

console.log("*** typeof")
console.log(typeof foo)
console.log(typeof Foo)

console.log("*** static chain")
Foo.sub_s()
// Foo.base_s()
FooBase.base_s()
