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
class CreateLayerExample
{
    fun createLayer()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val layerPost = LayerPost(
            key = "checkout-flow",
            name = "Checkout Flow",
            description = "description_string",
        )

        try
        {
            val response = LayersApi().createLayer(
                projectKey = "projectKey_string",
                layerPost = layerPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling LayersApi#createLayer")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling LayersApi#createLayer")
            e.printStackTrace()
        }
    }
}
