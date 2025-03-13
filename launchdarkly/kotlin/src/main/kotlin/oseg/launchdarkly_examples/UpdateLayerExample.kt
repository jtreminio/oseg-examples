package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class UpdateLayerExample
{
    fun updateLayer()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val layerPatchInput = LayerPatchInput(
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "experimentKey": "checkout-button-color",
                        "kind": "updateExperimentReservation",
                        "reservationPercent": 25
                    }
                ]
            """)!!,
            comment = "Example comment describing the update",
            environmentKey = "production",
        )

        try
        {
            val response = LayersApi().updateLayer(
                projectKey = "projectKey_string",
                layerKey = "layerKey_string",
                layerPatchInput = layerPatchInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling LayersApi#updateLayer")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling LayersApi#updateLayer")
            e.printStackTrace()
        }
    }
}
