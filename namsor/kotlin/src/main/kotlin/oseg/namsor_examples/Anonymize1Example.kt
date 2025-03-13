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
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class Anonymize1Example
{
    fun anonymize1()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        try
        {
            val response = AdminApi().anonymize1(
                source = "source",
                anonymized = true,
                token = "token",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AdminApi#anonymize1")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AdminApi#anonymize1")
            e.printStackTrace()
        }
    }
}
