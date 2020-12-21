package com.example.ar_test_3;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;


import com.google.ar.core.Anchor;
import com.google.ar.core.AugmentedImage;
import com.google.ar.core.AugmentedImageDatabase;
import com.google.ar.core.Config;
import com.google.ar.core.Frame;
import com.google.ar.core.Session;
import com.google.ar.core.TrackingState;
import com.google.ar.sceneform.AnchorNode;
import com.google.ar.sceneform.FrameTime;
import com.google.ar.sceneform.Scene;
import com.google.ar.sceneform.rendering.ModelRenderable;
import com.google.ar.sceneform.ux.ArFragment;
import com.google.ar.sceneform.ux.TransformableNode;

import java.util.BitSet;
import java.util.Collection;


public class MainActivity extends AppCompatActivity implements Scene.OnUpdateListener {

    private CustomArFragment arFragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        arFragment = (CustomArFragment) getSupportFragmentManager().findFragmentById(R.id.AR_fragment);
        arFragment.getArSceneView().getScene().addOnUpdateListener(this);
    }

    public void setupDatabase(Config config, Session session) {
        Bitmap bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.pic);
        AugmentedImageDatabase aid = new AugmentedImageDatabase(session);
        aid.addImage("deer", bitmap);
        config.setAugmentedImageDatabase(aid);

    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    @Override
    public void onUpdate(FrameTime frameTime) {

        Frame frame =  arFragment.getArSceneView().getArFrame();
        Collection <AugmentedImage> images = frame.getUpdatedTrackables(AugmentedImage.class);

        for (AugmentedImage image : images) {
            if (image.getTrackingState() == TrackingState.TRACKING) {
                if (image.getName().equals("deer")) {
                    Anchor anchor = image.createAnchor(image.getCenterPose());

                    createModel(anchor);
                }

            }
        }
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private void createModel(Anchor anchor) {

        ModelRenderable.builder()
                .setSource(this, Uri.parse("deer.sfb"))
                .build()
                .thenAccept(ModelRenderable -> placeModel( ModelRenderable, anchor));


    }

    private void placeModel(ModelRenderable modelRenderable, Anchor anchor) {

        AnchorNode anchorNode = new AnchorNode(anchor);
        anchorNode.setRenderable(modelRenderable);
        TransformableNode transformableNode = new TransformableNode(arFragment.getTransformationSystem());
        transformableNode.setParent(anchorNode);
        transformableNode.setRenderable(modelRenderable);
        arFragment.getArSceneView().getScene().addChild(anchorNode);
        transformableNode.select();

    }
}
