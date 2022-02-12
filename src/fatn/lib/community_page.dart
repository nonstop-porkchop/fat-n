import 'package:flutter/material.dart';
import 'package:cloud_firestore/cloud_firestore.dart';

class CommunityPage extends StatefulWidget {
  const CommunityPage({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() => _CommunityPageState();
}

class _CommunityPageState extends State<CommunityPage> {
  CollectionReference posts = FirebaseFirestore.instance.collection('posts');

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: StreamBuilder<QuerySnapshot>(
            builder: postsBuilder, stream: posts.snapshots()),
        floatingActionButton: FloatingActionButton(
          onPressed: () => Navigator.push(
              context,
              MaterialPageRoute(
                  builder: (BuildContext context) => const NewPostPage())),
          tooltip: 'New',
          child: const Icon(Icons.add),
        ));
  }

  Widget postsBuilder(
      BuildContext context, AsyncSnapshot<QuerySnapshot<dynamic>> index) {
    if (!index.hasData) return const CircularProgressIndicator();
    return ListView(
      children: index.data!.docs.map((doc) {
        return Card(
            margin: const EdgeInsets.all(10),
            child: Column(children: [
              Row(children: [
                Container(
                    margin: const EdgeInsets.all(5),
                    child: const Image(
                      image: NetworkImage(
                          "https://pbs.twimg.com/profile_images/1423223099588153348/F0wJnxyf_400x400.jpg",
                          scale: 7),
                    )),
                Container(
                    margin: const EdgeInsets.all(5),
                    child: Text(doc.data()['body_text']))
              ]),
              Row(
                children: [
                  Container(
                    child: ElevatedButton(
                        child: const Text('LIKE'), onPressed: like),
                    margin: const EdgeInsets.only(left: 5, bottom: 5),
                  ),
                  Container(
                    child: ElevatedButton(
                        child: const Text('MOOD'), onPressed: mood),
                    margin: const EdgeInsets.only(left: 5, bottom: 5),
                  ),
                  Container(
                    child: ElevatedButton(
                        child: const Text('COMMENT'), onPressed: comment),
                    margin: const EdgeInsets.only(left: 5, bottom: 5),
                  ),
                ],
              )
            ]));
      }).toList(),
    );
  }

  void comment() {
    throw Exception('Not implemented.');
  }

  void like() {
    throw Exception('Not implemented.');
  }

  void mood() {
    throw Exception('Not implemented.');
  }
}

class NewPostPage extends StatefulWidget {
  const NewPostPage({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() => _NewPostPageState();
}

class _NewPostPageState extends State<NewPostPage> {
  CollectionReference posts = FirebaseFirestore.instance.collection('posts');
  String bodyText = '';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          TextButton(
            onPressed: () => posts.add({'body_text': bodyText}).then(
                (value) => Navigator.pop(context)),
            child: const Text("Share"),
          ),
          TextField(onChanged: (value) {
            setState(() {
              bodyText = value;
            });
          }),
          const Text("TODO: Select who to share with...")
        ],
      ),
    );
  }
}
