
import "./mm/foo"

console.log("hello, javascript! (no stacktrace)")
// enable js stacktrace in print (= console.log)
enableStacktrace(true)
console.log("hello, javascript! again!! (with stacktrace)")

addSearchPath("Assets/Examples/Scripts/libs")

dofile("protobuf-library.js");
dofile("test.pb.js");

// test protobuf
// (function () {
//     // let writer = protobuf.Writer.create()
//     let msg = new protos.Ping()
//     msg.payload = "hello, protobuf"
//     msg.time = 123
//     let w = protos.Ping.encode(msg)
//     let buf = w.finish()

//     // > go run examples\echoserver\src\main.go
//     // you need a simple echo server to run the code below
//     let ws = new DuktapeJS.WebSocket()
//     ws.connect("ws://127.0.0.1:8080/websocket")
//     ws.on("open", this, () => {
//         console.log("ws opened")
//         ws.send(buf)
//     })
//     ws.on("close", this, () => {
//         console.log("ws closed")
//     })
//     ws.on("data", this, data => {
//         let dmsg = protos.Ping.decode(data)
//         console.log(`msg.payload = ${dmsg.payload}`)
//         console.log(`msg.time = ${dmsg.time}`)
//     })
//     let go = new UnityEngine.GameObject("ws")
//     go.AddComponent(DuktapeJS.Bridge).SetBridge({
//         Update: () => {
//             ws.poll()
//         },
//         OnDestroy: () => {
//             console.log("ws close")
//             ws.close()
//         },
//     })
// })();

(function () {
    let Vector3 = UnityEngine.Vector3
    let start = Date.now()
    for (let i = 1; i < 200000; i++) {
        let v = new Vector3(i, i, i)
        v.Normalize()
    }
    console.log("vector3/js ", (Date.now() - start) / 1000);
})();

(function () {
    console.log("### Vector3 (replaced)")
    let v1 = new UnityEngine.Vector3(1, 2, 3)
    console.log(`v: ${v1.x}, ${v1.y}, ${v1.z} (${v1.magnitude})`)
    console.log(`v: ${v1[0]}, ${v1[1]}, ${v1[2]}`)
    let v2 = v1.normalized
    console.log(`v: ${v2.x}, ${v2.y}, ${v2.z} (${v2.magnitude})`)
    v2.x += 10
    console.log(`v: ${v2.x}, ${v2.y}, ${v2.z} (${v2.magnitude})`)

    let q1 = new UnityEngine.Quaternion(1, 2, 3, 1)
    console.log(`q: ${q1.x}, ${q1.y}, ${q1.z} eulerAngles: ${q1.eulerAngles.ToString()}`)
})();

(function () {
    console.log("### Delegates begin")
    let d = new DuktapeJS.Delegate0<void>()
    d.on(this, () => {
        console.log("delegate0")
    })
    d.dispatch()
    d.clear()
    d.dispatch()
    console.log("### Delegates end")
})();

(function () {
    SampleNamespace.SampleClass.TestDelegate(function () {
        console.log(this, "TestDelegate")
    })
    let d = new DuktapeJS.Dispatcher()
    d.on("this", function () {
        console.log(this, "TestDelegate")
    })
    SampleNamespace.SampleClass.TestDelegate(d)
})();

console.log(UnityEngine.Mathf.PI)
// UnityEngine.Debug.Log("greeting")
let go = UnityEngine.GameObject.CreatePrimitive(UnityEngine.PrimitiveType.Cube)
go.name = "testing_cube"
let hello = go.AddComponent(SampleNamespace.Hello)
let bridge = go.AddComponent(DuktapeJS.Bridge)

class MyBridge {
    hitInfo: any = {}
    gameObject: UnityEngine.GameObject
    private rotx = 10
    private roty = 20

    constructor(gameObject: UnityEngine.GameObject) {
        this.gameObject = gameObject
    }

    OnEnable() {
        console.log("bridge.OnEnable")
    }

    Start() {
        console.log("bridge.Start")
        this.gameObject.transform.localPosition = new UnityEngine.Vector3(3, 0, 0)
    }

    OnDisable() {
        console.log("bridge.OnDisable")
    }

    Update() {
        this.gameObject.transform.localRotation = UnityEngine.Quaternion.Euler(this.rotx, this.roty, 0)
        this.rotx += UnityEngine.Time.deltaTime * 30
        this.roty += UnityEngine.Time.deltaTime * 15
        if (UnityEngine.Input.GetMouseButtonUp(0)) {
            if (UnityExtensions.RaycastMousePosition(this.hitInfo, 1000, 1)) {
                console.log("you clicked " + this.hitInfo.collider.name)
            } 
        }
    }

    OnDestroy() {
        console.log("bridge.OnDestroy")
    }
}
bridge.SetBridge(new MyBridge(go))

console.log("hello.name = ", hello.gameObject.name)
let go2 = new UnityEngine.GameObject("testing2_wait_destroy")
console.log("go2.activeSelf", go2.activeSelf)
console.log("go2.activeSelf", go2.activeSelf)

setTimeout(() => {
    go2.SetActive(false)
}, 3500)

setTimeout(() => {
    UnityEngine.Object.Destroy(go2)
}, 30000)

// console.log(UnityEngine.UI.Text)
let textui = UnityEngine.GameObject.Find("/Canvas/Text").GetComponent(UnityEngine.UI.Text)
if (textui) {
    textui.text = "hello, javascript"
}

let buttonui = UnityEngine.GameObject.Find("/Canvas/Button").GetComponent(UnityEngine.UI.Button)
if (buttonui) {
    let delegate = new DuktapeJS.Delegate0<void>()
    delegate.on(buttonui, () => {
        if (textui) {
            textui.color = UnityEngine.Color.Lerp(UnityEngine.Color.black, UnityEngine.Color.green, UnityEngine.Random.value)
        }
        console.log("you clicked the button")
    })
    delegate.on(buttonui, function () {
        console.log("another listener", this == buttonui)
    })
    buttonui.onClick.AddListener(delegate)
}