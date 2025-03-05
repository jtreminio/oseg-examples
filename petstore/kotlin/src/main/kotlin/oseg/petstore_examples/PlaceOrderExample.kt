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

class PlaceOrderExample
{
    fun placeOrder()
    {
        ApiClient.accessToken = "YOUR_ACCESS_TOKEN"
        // ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val order = Order(
            id = 12345,
            petId = 98765,
            quantity = 5,
            shipDate = OffsetDateTime.parse("2025-01-01T17:32:28Z"),
            status = Order.Status.approved,
            complete = false,
        )

        try
        {
            val response = StoreApi().placeOrder(
                order = order,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling StoreApi#placeOrder")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling StoreApi#placeOrder")
            e.printStackTrace()
        }
    }
}
