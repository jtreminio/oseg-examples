package oseg.petstore_examples

import org.openapitools.client.infrastructure.*
import org.openapitools.client.apis.*
import org.openapitools.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class DeleteOrderExample
{
    fun deleteOrder()
    {
        ApiClient.accessToken = "YOUR_ACCESS_TOKEN"
        // ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            StoreApi().deleteOrder(
                orderId = "12345",
            )
        } catch (e: ClientException) {
            println("4xx response calling StoreApi#deleteOrder")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling StoreApi#deleteOrder")
            e.printStackTrace()
        }
    }
}
