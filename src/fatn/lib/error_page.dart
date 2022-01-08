import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:url_launcher/url_launcher.dart';

class ErrorPage extends StatefulWidget {
  const ErrorPage({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() => _ErrorPageState();
}

class _ErrorPageState extends State<ErrorPage> {
  static const _darkThemeTextStyle = TextStyle(color: Colors.white);
  static const _issuesPageUrl =
      'https://github.com/nonstop-porkchop/fat-n/issues';
  var _urlOpenFailureMessage = "";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
          child: Column(
        children: [
          const Text("Error",
              style: TextStyle(fontSize: 34, color: Colors.redAccent)),
          const SizedBox(height: 10),
          const Image(image: AssetImage("images/does_not_compute.png")),
          const SizedBox(height: 10),
          RichText(
            text: TextSpan(
              children: [
                const TextSpan(
                    text:
                        "An error occurred, please report (or fix) your issue on ",
                    style: _darkThemeTextStyle),
                TextSpan(
                    text: "our GitHub page",
                    style: const TextStyle(
                        color: Colors.blue,
                        decoration: TextDecoration.underline),
                    recognizer: TapGestureRecognizer()
                      ..onTap = () async {
                        if (await canLaunch(_issuesPageUrl)) {
                          await launch(_issuesPageUrl);
                        } else {
                          setState(() {
                            _urlOpenFailureMessage =
                                "Failed to open link automatically, here's the link for you: " +
                                    _issuesPageUrl;
                          });
                        }
                      }),
                const TextSpan(text: ".", style: _darkThemeTextStyle)
              ],
            ),
          ),
          SelectableText(
            _urlOpenFailureMessage,
            style: const TextStyle(color: Colors.redAccent),
          )
        ],
        mainAxisAlignment: MainAxisAlignment.center,
      )),
    );
  }
}
