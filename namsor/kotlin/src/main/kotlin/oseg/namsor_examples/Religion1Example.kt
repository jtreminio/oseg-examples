package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class Religion1Example
{
    fun religion1()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = IndianApi().religion1(
                subDivisionIso31662 = "IN-UP",
                firstName = "Akash",
                lastName = "Sharma",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IndianApi#religion1")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IndianApi#religion1")
            e.printStackTrace()
        }
    }
}
